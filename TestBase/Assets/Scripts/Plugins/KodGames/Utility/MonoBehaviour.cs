using UnityEngine;
using System.Collections;

// Overwrite UnityEngine.MonoBehaviour
public class MonoBehaviour : UnityEngine.MonoBehaviour
{
	private Animation cachedAnimation = null;
	public Animation CachedAnimation
	{
		get { return cachedAnimation != null ? cachedAnimation : cachedAnimation = GetComponent<Animation>(); }
	}

	private AudioSource cachedAudio = null;
	public AudioSource CachedAudio 
	{
		get { return cachedAudio != null ? cachedAudio : cachedAudio = GetComponent<AudioSource>(); }
	}

	private Camera cachedCamera = null;
	public Camera CachedCamera 
	{
		get { return cachedCamera != null ? cachedCamera : cachedCamera = GetComponent<Camera>(); }
	}

	private Collider cachedCollider = null;
	public Collider CachedCollider 
	{
		get { return cachedCollider != null ? cachedCollider : cachedCollider = GetComponent<Collider>(); }
	}

	private ConstantForce cachedConstantForce = null;
	public ConstantForce CachedConstantForce 
	{
		get { return cachedConstantForce != null ? cachedConstantForce : cachedConstantForce = GetComponent<ConstantForce>(); }
	}

	private GUIText cachedGuiText = null;
	public GUIText CachedGuiText
	{
		get { return cachedGuiText != null ? cachedGuiText : cachedGuiText = GetComponent<GUIText>(); }
	}

	private GUITexture cachedGuiTexture = null;
	public GUITexture CachedGuiTexture 
	{
		get { return cachedGuiTexture != null ? cachedGuiTexture : cachedGuiTexture = GetComponent<GUITexture>(); }
	}

	private HingeJoint cachedHingeJoint = null;
	public HingeJoint CachedHingeJoint 
	{
		get { return cachedHingeJoint != null ? cachedHingeJoint : cachedHingeJoint = GetComponent<HingeJoint>(); }
	}

	private Light cachedLight = null;
	public Light CachedLight
	{
		get { return cachedLight != null ? cachedLight : cachedLight = GetComponent<Light>(); }
	}

	private NetworkView cachedNetworkView = null;
	public NetworkView CachedNetworkView 
	{
		get { return cachedNetworkView != null ? cachedNetworkView : cachedNetworkView = GetComponent<NetworkView>(); }
	}

	//private ParticleEmitter cachedParticleEmitter = null;
	//public ParticleEmitter CachedParticleEmitter 
	//{
	//	get { return cachedParticleEmitter != null ? cachedParticleEmitter : cachedParticleEmitter = GetComponent<ParticleEmitter>(); }
	//}

	private ParticleSystem cachedParticleSystem = null;
	public ParticleSystem CachedParticleSystem 
	{
		get { return cachedParticleSystem != null ? cachedParticleSystem : cachedParticleSystem = GetComponent<ParticleSystem>(); }
	}

	private Renderer cachedRenderer = null;
	public Renderer CachedRenderer
	{
		get { return cachedRenderer != null ? cachedRenderer : cachedRenderer = GetComponent<Renderer>(); }
	}

	private Rigidbody cachedRigidbody = null;
	public Rigidbody CachedRigidbody 
	{
		get { return cachedRigidbody != null ? cachedRigidbody : cachedRigidbody = GetComponent<Rigidbody>(); }
	}

	private Transform cachedTransform = null;
	public Transform CachedTransform
	{
		get { return cachedTransform != null ? cachedTransform : cachedTransform = GetComponent<Transform>(); }
	}


}

