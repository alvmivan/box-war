using System.Collections.Generic;
using UnityEngine;

public class Arsenal : MonoBehaviour
{
    public List<string> weaponsEnabled;

    public List<Weapon> allWeapons;

    public void EnableAll()
    {
        foreach (var weapon in allWeapons)
        {
            //si tengo comprada el arma, la activo
            //weapon.SetShooting(WeaponsEnabled.Contains(weapon.weaponId));//lo activamos al codigo cuando tengamos el inventario funcionando
            weapon.SetShooting(true);                
        }
    }

    public void DisableAll()
    {
        foreach (var weapon in allWeapons)
            weapon.SetShooting(false);
    }
}