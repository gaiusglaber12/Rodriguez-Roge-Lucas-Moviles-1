using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletMover : ManejoPallets {

    public Joystick joystick;

    public ManejoPallets Desde, Hasta;
    bool segundoCompleto = false;

    private void Update() {
        if (!Tenencia() && Desde.Tenencia() && joystick.Horizontal < -0.9f)
        {
            PrimerPaso();
        }
        if (Tenencia() && joystick.Vertical< -0.9f)
        {
            SegundoPaso();
        }
        if (segundoCompleto && Tenencia() && joystick.Horizontal > 0.9f)
        {
            TercerPaso();
        }
    }

    void PrimerPaso() {
        Desde.Dar(this);
        segundoCompleto = false;
    }
    void SegundoPaso() {
        base.Pallets[0].transform.position = transform.position;
        segundoCompleto = true;
    }
    void TercerPaso() {
        Dar(Hasta);
        segundoCompleto = false;
    }

    public override void Dar(ManejoPallets receptor) {
        if (Tenencia()) {
            if (receptor.Recibir(Pallets[0])) {
                Pallets.RemoveAt(0);
            }
        }
    }
    public override bool Recibir(Pallet pallet) {
        if (!Tenencia()) {
            pallet.Portador = this.gameObject;
            base.Recibir(pallet);
            return true;
        }
        else
            return false;
    }
}
