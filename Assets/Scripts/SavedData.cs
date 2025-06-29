using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SavedData
{
    public bool savedspaSpain;
    public bool savedengAmerican;
    public bool savedspaColombian;

    public int savednumEvilWizard;
    public int savednumEvilWizardGerard;
    public int savednumEvilWizardManolo;
    public int savednumEvilWizardManoloMano;
    public int savednumEvilWizardElidora;
    public int savednumEvilWizardPijus;
               
    public int savednumHybrid;
    public int savednumHybridElvog;
    public int savednumHybridLepion;
    public int savednumHybridMara;
    public int savednumHybridPetra;
    public int savednumHybridSaltaralisis;
               
    public int savednumLimbastic;
    public int savednumLimbasticAntonio;
    public int savednumLimbasticGiovanni;
    public int savednumLimbasticCululu;
    public int savednumLimbasticSergio;
    public int savednumLimbasticPatxi;
               
    public int savednumElemental;
    public int savednumElementalTapicio;
    public int savednumElementalRockon;
    public int savednumElementalHandy;
    public int savednumElementalJissy;
    public int savednumElementalHueso;

    public int SavednumElectroped;
    //[SerializeField] public int numElectropedDenjirenji;
    //[SerializeField] public int numElectropedMagmaDora;
    //[SerializeField] public int numElectropedMasermati;
    //[SerializeField] public int numElectropedRaven;
    //[SerializeField] public int numElectropedRustica;

    public bool savedsamuraiPagaMal = false;
    public bool savedborrachoTriste = false;
    public bool savedsamuraiAyudado1 = false;
    public bool savedsamuraiAyudado2 = false;
    public int savedvecesSamuraiAyudado = 0;

    public bool savedday0Check = false;
    public bool savedday1Check = false;
    public bool savedday2Check = false;
    public bool savedday3Check = false;
    public bool savedday4Check = false;
    public bool savedday5Check = false;
    public bool savedvideoActivo = false;
    public bool savedvideoVisto = false;
    public bool savedfinalMuyMaloConseguido = false;
    public bool savedfinalMaloConseguido = false;
    public bool savedfinalBuenoConseguido = false;
    public bool savedfinalMuyBuenoConseguido = false;
    public bool savedfinalSecretoConseguido = false;
    public int savedtipsPoints;
    public int saveddetectivePoints;

    public bool savedfase1Check = false;
    public bool savedfase2Check = false;
    public bool savedfase3Check = false;
    public bool savedfase4Check = false;
    public bool savedfase5Check = false;
    public bool savedfase6Check = false;
    public bool savedfase7Check = false;
    public bool savedfase8Check = false;
    public bool savedfase9Check = false;

    public bool savedsePueTocar = false;
    public bool savedyaSeFueCliente = false;
    public float savedtipsBetweenDays = 0;

    public int savedvecesCobradoCululu = 0;                 // Si le cobras 3 veces bien (día 1, 4 y 5), te llevas la foto de la cangumantis en pose sugerente
    public int savedvecesCobradoGiovanni = 0;               // Si le cobras 2 veces bien (día 1 y 2), te llevas un libro que es la bomba.
    public int savedvecesCobradaMara = 0;                   // Si le cobras 2 veces bien (día 1 y 2), te llevas una pata de la suerte.
    public int savedvecesCobradaHandy = 0;                   // Si le cobras 2 veces bien (día 2 y 4), eres un puto payaso.
    public int savednoCobrarSergioCobrarGeeraardD4 = 0;                   // No tienes que cobrar a Sergio en el día 4 y tienes que cobrar a Geerald en el día 4
    public int savedvecesCobradoAntonio = 0;                   // Tienes que cobrar a Antonio en el dia 4 y a Paxi en el dia 3
    public int savedvecesCobradoRaven = 0;
    public int savednumGnomosFinded = 0;
    public bool savednerviosusPagaLoQueDebe = false;        // Si le cobras (día 4) te da la globoespada.
    public bool savednerviosusTeDebePasta = false;          // Si no le cobras Gerardo el magias te dará su bella foto.
    public bool savedslimeFostiados = false;                // Si le has dado hasta en el carnet de identidad a los slimes.
    public bool savedslimeFail = false;                     // Si no llegaste a 50 puntos en el minijuego de Elidora.
    public bool savedelidoraAcariciada = false;             // Si le metiste tremendo cebollazo al pedrolo de Elidora.

    public bool savedgiftGeeraard = false;      // Si nerviosusPagaLoQueDebe es falso, Geerard te dará la foto firmada
    public bool savedgiftEnano = false;         // Te da un Enano. Si en el día 2 o 3 encuentras al enano zumbón.
    public bool savedgiftMano = false;          // Te da un anillo.
    public bool savedgiftElidora = false;       // Si completas su minijuego te pasa un moco.
    //[SerializeField] public bool giftPijus = false;
    public bool savedgiftElvog = false;         // Te da una botella con flores.
    //[SerializeField] public bool giftLepion = false;
    public bool savedgiftMara = false;          // Te da la pierna de su marido.
    public bool savedgiftPetra = false;         // Te da un mapa.
    //[SerializeField] public bool giftSaltaralisis = false;
    public bool savedgiftAntonio = false;       // Te da sus gafas.
    public bool savedgiftGiovanni = false;      // Te da su "libro de cocina".
    public bool savedgiftCululu = false;        // Te da la foto de Mara.
    public bool savedgiftSergio = false;        // Si nerviosusPagaLoQueDebe es verdadero, te da su Globo-Espada.
    //[SerializeField] public bool giftPatxi = false;         
    public bool savedgiftTapicio = false;       // Te da el puto GOTY.
    //[SerializeField] public bool giftRockon = false;
    public bool savedgiftHandy = false;         // Te da un disfraz de payaso.
    //[SerializeField] public bool giftJissy = false;
    //[SerializeField] public bool giftHueso = false;
    public bool savedgiftDenjirenji = false;    // Si completas su minijuego te da su espada.
    //[SerializeField] public bool giftMagmadora = false;
    //[SerializeField] public bool giftMasermati = false;
    public bool savedgiftRaven = false;         // Si completas su minijuego te da un disco.
                                                //[SerializeField] public bool giftRustica = false;
    public string fechaUltimoGuardado;
    public int ultimoDiaJugado;
}