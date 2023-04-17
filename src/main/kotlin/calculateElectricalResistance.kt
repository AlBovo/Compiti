fun calculateElectricalResistance(voltageInVolts: Double, currentInAmpere: Double): Double{
    require(voltageInVolts >= 0){
        "The voltage cannot be negative"
    }
    require(currentInAmpere > 0){
        "The electric current cannot be lower or equal to 0"
    }
    val resistanceInOhm = voltageInVolts / currentInAmpere
    return resistanceInOhm
}