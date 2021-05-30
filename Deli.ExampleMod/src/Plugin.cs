using Deli.Immediate;
using Deli.Setup;
using FistVR;
using UnityEngine.SceneManagement;
using BepInEx.Configuration;


namespace GameManagerTutorial
{
	public class Plugin : DeliBehaviour
	{
		public ConfigEntry<PowerupType>			Powerup;
		public ConfigEntry<PowerUpIntensity>	Intensity;
		public ConfigEntry<PowerUpDuration>		Duration; 

		public Plugin()
		{
			Logger.LogInfo("Loading GameManager tutorial");

			Powerup = Config.Bind
				(
					"Powerup options",
					"PowerupType",
					PowerupType.InfiniteAmmo,
					"What powerup to give on scene load"
				);

			Intensity = Config.Bind
				(
					"Powerup options",
					"PowerupIntensity",
					PowerUpIntensity.High,
					"How intense this powerup will be"
				);

			Duration = Config.Bind
				(
					"Powerup options",
					"PowerupDuration",
					PowerUpDuration.Full,
					"How long will the powerup last for"
				);

			SceneManager.sceneLoaded += SceneLoaded;
			Logger.LogInfo("Subscribed to SceneLoaded");

		}	

		private void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
			GM.CurrentPlayerBody.ActivatePower(Powerup.Value, Intensity.Value, Duration.Value, false, false);
			Logger.LogInfo("Gave player the power of " + PowerupType.InfiniteAmmo);
		}
	}
}