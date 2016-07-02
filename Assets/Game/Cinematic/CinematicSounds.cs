using UnityEngine;
using System.Collections;

public class CinematicSounds : MonoBehaviour {

    [SerializeField]
    AudioClip sheildHitSound;
    [SerializeField]
    AudioClip punchSound;
    [SerializeField]
    AudioClip shieldPowerUpSound;

    [SerializeField]
    AudioClip boxHitSound;
    [SerializeField]
    AudioClip boxFallSound;

    [SerializeField]
    AudioClip bossSurprisedSound;
    [SerializeField]
    AudioClip bossPointSound;
    [SerializeField]
    AudioClip bossSecondPointSound;
    [SerializeField]
    AudioClip bossLaughSound;
    [SerializeField]
    AudioClip bossSecondLaughSound;
    [SerializeField]
    AudioClip bossWindUpSound;
    [SerializeField]
    AudioClip bossSecondWindUpSound;
    [SerializeField]
    AudioClip bossSpeakSound;
    [SerializeField]
    AudioClip bossSecondSpeakSound;

    [SerializeField]
    AudioClip meleeLaughSound;
    [SerializeField]
    AudioClip meleeSecondLaughSound;

    [SerializeField]
    AudioClip companionBeep;
    [SerializeField]
    AudioClip companSecondBeep;
    [SerializeField]
    AudioClip companThirdBeep;
    [SerializeField]
    AudioClip companFourthBeep;

    [SerializeField]
    AudioClip playerEmojiSound;
    [SerializeField]
    AudioClip playerSecondEmojiSound;
    [SerializeField]
    AudioClip playerThirdEmojiSound;
    [SerializeField]
    AudioClip playerSadSound;

    /// SHIELD
    public void ShieldHitSound()
    {
        SoundManager.PlaySoundOneshot(sheildHitSound);
    }
    public void PunchSound()
    {
        SoundManager.PlaySoundOneshot(punchSound);
    }
    public void ShieldPowerUpSound()
    {
        SoundManager.PlaySoundOneshot(shieldPowerUpSound);
    }

    /// MISC
    public void BoxHitSound()
    {
        SoundManager.PlaySoundOneshot(boxHitSound);
    }
    public void BoxFallSound()
    {
        SoundManager.PlaySoundOneshot(boxFallSound);
    }

    /// BOSS
    public void BossSurprisedSound()
    {
        SoundManager.PlaySoundOneshot(bossSurprisedSound);
    }
    public void BossPointSound()
    {
        SoundManager.PlaySoundOneshot(bossPointSound);
    }
    public void BossSecondPointSound()
    {
        SoundManager.PlaySoundOneshot(bossSecondPointSound);
    }
    public void BossLaughSound()
    {
        SoundManager.PlaySoundOneshot(bossLaughSound);
    }
    public void BossSecondLaughSound()
    {
        SoundManager.PlaySoundOneshot(bossSecondLaughSound);
    }
    public void BossWindUpSound()
    {
        SoundManager.PlaySoundOneshot(bossWindUpSound);
    }
    public void BossSecondWindUpSound()
    {
        SoundManager.PlaySoundOneshot(bossSecondWindUpSound);
    }
    public void BossSpeakSound()
    {
        SoundManager.PlaySoundOneshot(bossSpeakSound);
    }
    public void BossSecondSpeakSound()
    {
        SoundManager.PlaySoundOneshot(bossSecondSpeakSound);
    }

    /// MELEE ROBOT
    public void MeleeLaughSound()
    {
        SoundManager.PlaySoundOneshot(meleeLaughSound);
    }
    public void MeleeSecondLaughSound()
    {
        SoundManager.PlaySoundOneshot(meleeSecondLaughSound);
    }

    /// COMPANION
    public void CompanionBeep()
    {
        SoundManager.PlaySoundOneshot(companionBeep);
    }
    public void CompanionSecondBeep()
    {
        SoundManager.PlaySoundOneshot(companSecondBeep);
    }
    public void CompanionThirdBeep()
    {
        SoundManager.PlaySoundOneshot(companThirdBeep);
    }
    public void CompanionFourthBeep()
    {
        SoundManager.PlaySoundOneshot(companFourthBeep);
    }

    /// PLAYER
    public void PlayerEmojiSound()
    {
        SoundManager.PlaySoundOneshot(playerEmojiSound);
    }
    public void PlayerSecondEmojiSound()
    {
        SoundManager.PlaySoundOneshot(playerSecondEmojiSound);
    }
    public void PlayerSadSound()
    {
        SoundManager.PlaySoundOneshot(playerSadSound);
    }
    public void PlayerThirdEmojiSound()
    {
        SoundManager.PlaySoundOneshot(playerThirdEmojiSound);
    }
}
