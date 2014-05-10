using System;
namespace MensErgerJeNiet.SpeelStuk
{
    interface IPion
    {
        MensErgerJeNiet.Kleur Kleur { get; set; }
        event EventHandler onmove;
    }
}
