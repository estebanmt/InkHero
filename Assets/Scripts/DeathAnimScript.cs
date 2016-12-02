using UnityEngine;
using System.Collections;

public class DeathAnimScript : MonoBehaviour {
	private float cambio_y = 0f;
	private float AUMENTO_EN_Y = 10.5f;
	private float ALTURA_MAXIMA = 11f;
	private bool llego_arriba = false;
	private bool llego_abajo = false;
	private float tiempo_espera_inicial = 0f;
	private float TIEMPO_ESPERA_MAXIMO_INICIAL = 0.8f;
	private float tiempo_extra = 0f;
	private float TIEMPO_EXTRA_MAXIMO = 0.4f;
	public AudioClip collectSound;
	public AudioClip clip_muerte;
	private float VOLUMEN_AUDIO = 0.3f;


	// Use this for initialization

	void Start () {
		AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource aud in audios)
			aud.Stop();
		//play sound
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = collectSound;
		AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
		audioSource2.clip = clip_muerte;
		audioSource.volume = VOLUMEN_AUDIO;
		audioSource2.volume = VOLUMEN_AUDIO;
		audioSource2.Play();
		audioSource.PlayDelayed (TIEMPO_ESPERA_MAXIMO_INICIAL);

		
	}
	
	// Update is called once per frame
	void Update () {
		if(tiempo_espera_inicial < TIEMPO_ESPERA_MAXIMO_INICIAL){
			tiempo_espera_inicial += Time.deltaTime;
		}
		else if (!llego_arriba) {
			Vector3 temp = transform.position;
			temp.y += Time.deltaTime * AUMENTO_EN_Y;
			transform.position = temp;
			cambio_y += Time.deltaTime * AUMENTO_EN_Y;
			if (cambio_y >= ALTURA_MAXIMA){
				llego_arriba = true;
			}
		} 
		else {
			Vector3 temp = transform.position;
			temp.y -= Time.deltaTime * AUMENTO_EN_Y;
			transform.position = temp;
			cambio_y -= Time.deltaTime * AUMENTO_EN_Y;
			if (cambio_y <= -ALTURA_MAXIMA){
				llego_abajo = true;
			}
			if (llego_abajo) {
				tiempo_extra += Time.deltaTime;
			}
			if (tiempo_extra >= TIEMPO_EXTRA_MAXIMO) {
				DestroyObject(gameObject);
			}
		}


	}
}
