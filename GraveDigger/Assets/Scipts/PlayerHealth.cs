using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;

public class PlayerHealth : Health
{
    [SerializeField] private FloatHolder _currentHealth;
    [SerializeField] private FloatHolder _maxHealth;

    private void Start()
    {
        _maxHealth.ChangeData(TotalHealth);
        _currentHealth.ChangeData(TotalHealth);
    }

    private void Update()
    {
        _currentHealth.ChangeData(CurrentHealth);
    }

    public void Regenerate()
    {
        CurrentHealth = _maxHealth.Variable;
        _currentHealth.ChangeData(CurrentHealth);
    }

    public override bool Damage(float damage, GameObject attacker, bool overrideImmuneTime)
    {
        if (_immuneLayers.Contains(attacker.layer))
            return false;
        if (_immune && !overrideImmuneTime)
            return false;
        if (_temporaryInvinsibility == attacker.layer)
            return false;

        _onDamaged?.Invoke();
        _onDamagedDirection?.Invoke(attacker.transform);
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            _currentHealth.ChangeData(CurrentHealth);
            _onDie?.Invoke();
            return true;
        }

        _immune = true;

        StartCoroutine(DeImmune());
        return true;
    }

    public void Regenerate(float regenerationAmount)
    {
        CurrentHealth += regenerationAmount;
        if (CurrentHealth > TotalHealth)
        {
            CurrentHealth = TotalHealth;
        }
        _currentHealth.ChangeData(CurrentHealth);
    }
}
