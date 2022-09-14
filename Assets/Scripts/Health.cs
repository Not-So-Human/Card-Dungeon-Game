using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    // Fields
    int _currentHealth;
    int _currentMaxHealth;
    // _ is a naming convention on fields

    // Properties
    public int healthAmount
    {
        // Sets the value for health
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    public int MaxHealth
    {
        // Sets the value for Max health
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    // Constructor
    public Health(int health, int maxHealth)
    {
        // Sets the health and max health in unity
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }
    // Methods
    public void Dmg(int dmgAmount)
    {
        // Damages the player
        if (_currentHealth > 0)
            _currentHealth -= dmgAmount;
    }
    public void Heal(int healAmount)
    {
        // Tells if the character should get healed or not.
        if (_currentHealth < _currentMaxHealth)
            _currentHealth += healAmount;
        if (_currentHealth > _currentMaxHealth)
            _currentMaxHealth = _currentMaxHealth;
    }
}
