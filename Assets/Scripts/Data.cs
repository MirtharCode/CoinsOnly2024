using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField] public static int numEvilWizard;
    [SerializeField] public static int numEvilWizardGerard;
    [SerializeField] public static int numEvilWizardManolo;
    [SerializeField] public static int numEvilWizardManoloMano;
    [SerializeField] public static int numEvilWizardElidora;
    [SerializeField] public static int numEvilWizardPijus;

    [SerializeField] public static int numHybrid;
    [SerializeField] public static int numHybridElvog;
    [SerializeField] public static int numHybridLepion;
    [SerializeField] public static int numHybridMara;
    [SerializeField] public static int numHybridPetra;
    [SerializeField] public static int numHybridSaltaralisis;

    [SerializeField] public static int numLimbastic;
    [SerializeField] public static int numLimbasticAntonio;
    [SerializeField] public static int numLimbasticGiovanni;
    [SerializeField] public static int numLimbasticCululu;
    [SerializeField] public static int numLimbasticSergio;
    [SerializeField] public static int numLimbasticPatxi;

    [SerializeField] public static int numElemental;
    [SerializeField] public static int numElementalTapicio;
    [SerializeField] public static int numElementalRockon;
    [SerializeField] public static int numElementalHandy;
    [SerializeField] public static int numElementalJissy;
    [SerializeField] public static int numElementalHueso;

    [SerializeField] public static int numElectroped;
    [SerializeField] public static int numElectropedDenjirenji;
    [SerializeField] public static int numElectropedMagmaDora;
    [SerializeField] public static int numElectropedMasermati;
    [SerializeField] public static int numElectropedRaven;
    [SerializeField] public static int numElectropedRustica;

    [SerializeField] public static bool samuraiTriste = false;
    [SerializeField] public static bool brrachoTriste = false;

    public static Data instance;

    void Start()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
