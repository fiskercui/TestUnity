#coding=utf-8
import re
import os
import codecs
import sys
import  xml.dom.minidom



default_encoding = 'utf-8'
if sys.getdefaultencoding() != default_encoding:
    reload(sys) 
    sys.setdefaultencoding(default_encoding)
 

out_cmd = '--cpp_out='
cpp_output="./netproto/"
csharp_cmd = "."
csharp_output = "./csharpoutput"
lua_output="./luaproto/protobuf/" 
js_output="./jsproto/" 
protoc_cmd = r'""proto_tool/protoc_client""'

defines=[]
enums=[]
messages=[]
messageNameForKey={}
msgs=[]

DataType=[
    "uint32","string","uint64","int32","int64","boolbytes","double","float","bytes"
]

PackedDataType=[
    "uint32","uint64","int32","int64","boolbytes","double","float","bytes"
]

class DefineNode:
    name=""
    desc=""
    lines=[]

class LineNode:
    name=""
    value=""
    desc=""

class MessageNode:
    name=""
    requrieds=[]
    desc=""
    
class RequiredNode:
    name=""
    type=""
    desc=""
    index=""
    tagName=""

class MsgNode:
    id=""
    type=""
    desc=""
    priority=10000

def findInMap(data, datamap):
    for x in datamap:
        if (x==data):
            return True
    return False

def findDataType(dataType):
    return findInMap(dataType, DataType)

def isAttrExist(obj,proper):
    #print obj.getAttribute(proper)
    if(obj.has_key(proper)):
        return True
    return False


def loadXML(xml_path):
    xml_path=os.path.normpath(xml_path)
    dom=xml.dom.minidom.parse(xml_path)
    root=dom.documentElement
    parseEnums(root)
    parseDefines(root)
    parseMessages(root)
    parseMsgGroup(root)

def loadExcelXml(xmlpath):
    xml_path=os.path.normpath(xmlpath)
    dom=xml.dom.minidom.parse(xmlpath)
    root=dom.documentElement
    parse_excel_struct(root)



#load defines    
def parseDefines(xdom):
    protoDefines=xdom.getElementsByTagName('define')
    for x in protoDefines:
        pDefine=DefineNode()
        pDefine.lines=[]
        pDefine.name=x._attrs['name'].nodeValue
        if(isAttrExist(x._attrs,'desc')):
            pDefine.desc=x._attrs['desc'].nodeValue
        for line in x.childNodes:  
            if(line.nodeType==1):
                pLine=LineNode()
                if(isAttrExist(line._attrs,'desc')):
                    pLine.desc=line._attrs['desc'].nodeValue
                pLine.name=line._attrs['name'].nodeValue
                pLine.value=line._attrs['value'].nodeValue
                pDefine.lines.append(pLine)
        defines.append(pDefine)

#load Enum    
def parseEnums(xdom):
    protoDefines=xdom.getElementsByTagName('enum')
    for x in protoDefines:
        lastValue = -1
        pDefine=DefineNode()
        pDefine.lines=[]
        pDefine.name=x._attrs['name'].nodeValue
        if(isAttrExist(x._attrs,'desc')):
            pDefine.desc=x._attrs['desc'].nodeValue
        for line in x.childNodes:  
            if(line.nodeType==1):
                pLine=LineNode()
                pLine.name=line._attrs['name'].nodeValue
                if(isAttrExist(line._attrs,'desc')):
                    pLine.desc=line._attrs['desc'].nodeValue
                if(isAttrExist(line._attrs,'value')):
                    pLine.value=line._attrs['value'].nodeValue
                else:
                    pLine.value=str(lastValue + 1)
                lastValue = int(pLine.value)
                pDefine.lines.append(pLine)
        enums.append(pDefine)


def parse_excel_struct(xdom):
    protomessages=xdom.getElementsByTagName('struct')
    for x in protomessages:
        pMessageNode=MessageNode()
        index = 1
        pMessageNode.name=x._attrs['name'].nodeValue
        if(isAttrExist(x._attrs,'desc')):
            pMessageNode.desc=x._attrs['desc'].nodeValue
        pMessageNode.requrieds=[]
        for line in x.childNodes:  
            if(line.nodeType==1):
                pRequiredNode=RequiredNode()
                pRequiredNode.index= '%d' %index
                index = index + 1
                pRequiredNode.name=line._attrs['name'].nodeValue

                if(isAttrExist(line._attrs,'desc')):
                    pRequiredNode.desc=line._attrs['desc'].nodeValue

                if (line._attrs['type'].nodeValue == 'int'):
                    pRequiredNode.type='int32'
                elif (line._attrs['type'].nodeValue == 'String'):
                    pRequiredNode.type='string'
                else:
                    pRequiredNode.type=line._attrs['type'].nodeValue
                if(isAttrExist(line._attrs,'refer')):
                    pRequiredNode.tagName='repeated'
                else:
                    pRequiredNode.tagName='required'

                pMessageNode.requrieds.append(pRequiredNode)
        messages.append(pMessageNode)
        messageNameForKey[pMessageNode.name]=pMessageNode


#load messages
def parseMessages(xdom):
    protomessages=xdom.getElementsByTagName('message')
    for x in protomessages:
        pMessageNode=MessageNode()
        pMessageNode.name=x._attrs['name'].nodeValue
        if(isAttrExist(x._attrs,'desc')):
            pMessageNode.desc=x._attrs['desc'].nodeValue
        pMessageNode.requrieds=[]
        for line in x.childNodes:  
            if(line.nodeType==1):
                pRequiredNode=RequiredNode()
                if(isAttrExist(line._attrs,'desc')):
                    pRequiredNode.desc=line._attrs['desc'].nodeValue
                pRequiredNode.name=line._attrs['name'].nodeValue
                pRequiredNode.type=line._attrs['type'].nodeValue
                pRequiredNode.index=line._attrs['index'].nodeValue
		pRequiredNode.tagName=line.tagName
                pMessageNode.requrieds.append(pRequiredNode)
        messages.append(pMessageNode)
        messageNameForKey[pMessageNode.name]=pMessageNode


#load msgs        
def parseMsgGroup(xdom):
    protomesggroup=xdom.getElementsByTagName('msggroup')
    for x in protomesggroup:
            for line in x.childNodes:
                if(line.nodeType==1):
                    pMsgNode=MsgNode()
                    
                    if(isAttrExist(line._attrs,'desc')):
                        pMsgNode.desc=line._attrs['desc'].nodeValue
                    pMsgNode.id=line._attrs['id'].nodeValue
                    pMsgNode.type=line._attrs['type'].nodeValue
                    if(isAttrExist(line._attrs,'priority')):
                        pMsgNode.priority=line._attrs['priority'].nodeValue
                    msgs.append(pMsgNode)
            
#create Define H file
def writeDefine():
   for x in  defines:
       fileName=x.name
       f=open(os.path.normpath(cpp_output)+"/"+fileName+".h",'w')
       fcontent = []
       fcontent.append(r'#ifndef '+fileName.upper()+'_H')
       fcontent.append(r'#define '+fileName.upper()+'_H')
       for line in x.lines:
           if(line.desc!=""):
               fcontent.append(r'/**'+line.desc+'**/')
           fcontent.append(r'#define '+line.name+'  '+line.value)
       fcontent.append(r'#endif')
       fstr='\n'.join(fcontent)
       fstr=fstr.encode('gb2312');
       f.write(fstr)
       f.close()

#create Enum H file
def writeEnum():
   for x in  enums:
       fileName=x.name
       f=open(os.path.normpath(cpp_output)+"/"+fileName+".h",'w')
       fcontent = []
       fcontent.append(r'#ifndef '+fileName.upper()+'_H')
       fcontent.append(r'#define '+fileName.upper()+'_H')

       fcontent.append(r'/**'+x.desc+'**/')
       fcontent.append(r'enum ' + fileName + ' {')

       for line in x.lines:
           if(line.desc!=""):
               fcontent.append(r'/**'+line.desc+'**/')
           if(line.value!=""):
               fcontent.append(r'	'+line.name+' = '+line.value+' ,')
           else:
               fcontent.append(r'	'+line.name+' ,')

       fcontent.append(r'};')
       fcontent.append(r'#endif')
       fstr='\n'.join(fcontent)
       fstr=fstr.encode('gb2312');
       f.write(fstr)
       f.close()

#create Enum lua file
def writeEnumLua(): 
   for x in  enums:
       fileName=x.name
       f=open(os.path.normpath(lua_output)+"/"+fileName+".lua",'w')
       fcontent = []

       fcontent.append(r'--'+x.desc+' ')
       fcontent.append(r'module(' + '\'' + fileName + '\')')

       for line in x.lines:
           if(line.desc!=""):
               fcontent.append(r'--'+line.desc+' ')
           if(line.value!=""):
               fcontent.append(r''+line.name+' = '+line.value+' ')
           else:
               fcontent.append(r''+line.name+' ')

       fstr='\n'.join(fcontent)
       fstr=fstr.encode('utf8');
       f.write(fstr)
       f.close()

#create Enum js file 
def writeEnumJS(): 
   for x in  enums:
       fileName=x.name
       f=open(os.path.normpath(js_output)+"/"+fileName+".js",'w')
       fcontent = []

       fcontent.append(r'//'+x.desc+' ')
       fcontent.append(fileName + ' = {')

       for line in x.lines:
           if(line.desc!=""):
               fcontent.append(r'//'+line.desc+' ')
           if(line.value!=""):
               fcontent.append(r''+line.name+' : '+line.value+', ')
           else:
               fcontent.append(r''+line.name+' : 65536, ') 

       fcontent.append('};') 
       fcontent.append('exports = module.exports = '+fileName+';')  
       
       fstr='\n'.join(fcontent)
       fstr=fstr.encode('utf8');
       f.write(fstr)
       f.close()

#create message.proto
def writeMessage(dirname):
    for x in messages:
        fileName=x.name
        f=open(os.path.normpath(dirname)+"/"+fileName+".proto",'w')
        fheader = []
        fcontent = ['message '+ fileName]
        tmpDataType = DataType[:]
        fcontent.append('{')
        x.requrieds.sort(lambda x,y:cmp(x.index,y.index))
        for required in x.requrieds:
            if(findInMap(required.type, tmpDataType)):
                if (required.tagName == "repeated" and findInMap(required.type, PackedDataType)):
                    fcontent.append(' '+required.tagName+' '+required.type+' '+required.name+" = "+required.index+";")
                else :
                    fcontent.append(' '+required.tagName+' '+required.type+' '+required.name+" = "+required.index+";")
            else:
                fheader.append(r'import "'+required.type+'.proto";')
		tStr=' '+required.tagName+' '+required.type+' '+required.name+" = "+required.index+";"
                fcontent.append(' '+required.tagName+' '+required.type+' '+required.name+" = "+required.index+";")
                tmpDataType.append(required.type)
        fcontent.append('}\n')
        fstr='option optimize_for = LITE_RUNTIME;\n'+'\n'.join(fheader)+'\n'+'\n'.join(fcontent)
        f.write(fstr)
        f.close()
def writeMsggroup():
    rf=open(os.path.normpath("proto_tool")+"/ProtoPackTool.h",'r')
    wf=open(os.path.normpath(cpp_output)+"/ProtoPackTool.h",'w')       
    rf_cpp=open(os.path.normpath("proto_tool")+"/ProtoPackTool.cpp",'r')
    wf_cpp=open(os.path.normpath(cpp_output)+"/ProtoPackTool.cpp",'w')
    fcpp_staticobj = []

    fheader = []
    fcontent = []
    #msgHeader
    for defineItem in  defines:
        fheader.append('#include "'+defineItem.name+'.h"');
    for enumItem in  enums:
        fheader.append('#include "'+enumItem.name+'.h"');

    msgs.sort(lambda a,b:cmp(a.priority,b.priority))
    itemtypes = []
    for msgNodeItem in msgs:
        if (findInMap(msgNodeItem.type, itemtypes)):
            continue
        itemtypes.append(msgNodeItem.type)
        fcpp_staticobj.append(msgNodeItem.type+" "+msgNodeItem.type.lower()+";")

    for msgNodeItem in msgs:
        fheader.append('#include "'+msgNodeItem.type+'.pb.h"');
        if(msgNodeItem.desc!=""):
            fcontent.append("		/** "+msgNodeItem.desc+" **/")
        fcontent.append("		if((NetMsgId)msgId=="+msgNodeItem.id+"){")
        fcontent.append("		 "+msgNodeItem.type.lower()+".ParseFromArray(protoBuf,len);")
        fcontent.append("		 *result=(char*)&"+msgNodeItem.type.lower()+";")
        fcontent.append("		}")


 
    text=rf.read()
    rf.close()
    text=text.replace('$Proto_Header$',"\n".join(fheader))
    wf.write(text)
    wf.close()    


    text=rf_cpp.read()
    rf_cpp.close()
    text=text.replace('$Proto_StaticObject$',"\n".join(fcpp_staticobj))
    text=text.replace('$Proto_Content$',"\n".join(fcontent))
    wf_cpp.write(text)
    wf_cpp.close()

    

def walk_dir(dir,topdown=True):
    p = re.compile('.*\.proto');
    svn = re.compile(r'.*[\\/]\.svn[\\/]');
    for root, dirs, files in os.walk(dir, topdown):
        if svn.match(root):
            continue

        for name in files:
            if p.match(name):
  #              print(os.path.join(root, name))
                cmd = protoc_cmd + r'  -I./proto_src ' + out_cmd+cpp_output+' '
                cmd += os.path.join(root, name)
                print (cmd)
                os.system(cmd)

def walk_lua(dir,topdown=True):
    p = re.compile('.*\.proto');
    svn = re.compile(r'.*[\\/]\.svn[\\/]');
    for root, dirs, files in os.walk(dir, topdown):
        if svn.match(root):
            continue

        for name in files:
            if p.match(name):
  #              print(os.path.join(root, name))
                cmd = r'proto_tool\protoc.exe  -I./proto_src' + ' --plugin=protoc-gen-lua="proto_tool\protoc-gen-lua.bat"' + ' --lua_out=./luaproto/protobuf '
                cmd += os.path.join(root, name)
                print (cmd)
                os.system(cmd)


def walk_csharp(dir,topdown=True):
    p = re.compile('.*\.proto');
    svn = re.compile(r'.*[\\/]\.svn[\\/]');
    for root, dirs, files in os.walk(dir, topdown):
        if svn.match(root):
            continue

        protoDir = os.getcwd()+"\\proto_src\\"
        print(protoDir)
        os.chdir(protoDir)
        for name in files:
            if p.match(name):
                nameArray = os.path.splitext(name)
                prefixName = nameArray[0]
                cmd = r'..\proto_tool\protogen.exe -i:' + name +  ' -q -o:../cs/' + prefixName + '.cs -ns:Pb' 
                # cmd += os.path.join(root, name)
                print (cmd)
                os.system(cmd)
        protoDir = os.getcwd()+"\\..\\"
        os.chdir(protoDir)


def write_luainit(dir,topdown=True):
    fileName="init";
    f=open(os.path.normpath(lua_output)+"/../"+fileName+".lua",'w');
    fcontent = [];
    fcontent.append(r'local _M = {}'); 
    fcontent.append(r'_M.descriptor  = import(".descriptor")');  
    fcontent.append(r'_M.text_format  = import(".text_format")');  
    fcontent.append(r'_M.containers  = import(".containers")');  
    fcontent.append(r'_M.listener  = import(".listener")');  
    fcontent.append(r'_M.wire_format  = import(".wire_format")');  
    fcontent.append(r'_M.encoder  = import(".encoder")');  
    fcontent.append(r'_M.decoder  = import(".decoder")');  
    fcontent.append(r'_M.type_checkers  = import(".type_checkers")');  
    fcontent.append(r'_M.protobuf  = import(".protobuf")');     

    p = re.compile('.*\.lua');
    svn = re.compile(r'.*[\\/]\.svn[\\/]');
    for root, dirs, files in os.walk(dir, topdown):
        if svn.match(root):
            continue

        for name in files:
            if p.match(name):
  #              print(os.path.join(root, name))
                nackedname = os.path.splitext(name)[0];
                fcontent.append(r'_M.'+nackedname+' = import(".protobuf.'+nackedname+'")');

    fcontent.append(r'return _M'); 
    fstr='\n'.join(fcontent);
    fstr=fstr.encode('utf8');
    f.write(fstr)
    f.close() 

def walk_as3(dir):
    p = re.compile('.*\.proto');
    svnn = re.compile(r'.*[\\/]\.svn[\\/]');
    for root, dirs, files in os.walk(dir, True):
	if svnn.match(root):
	    continue

	for name in files:
	    if p.match(name):
		cmd = 'protoc.exe' + ' -I./proto_src  --plugin=protoc-gen-as3="protoc-gen-as3.bat" --as3_out=./proto_as3Tool/GameProto/src '
		cmd += os.path.join(root, name)
		print (cmd)
		os.system(cmd) 
#loadXML(r'proto.xml')
#writeDefine()
#writeMessage()
#writeMsggroup()
#walk_dir(".")
