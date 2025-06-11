fun celsiusToKelvinTemperature(celsiusTemperature: Double): Double {
    require(celsiusTemperature >= -273.15){
        "Celsius temperature cannot be under absolute zero"
    }
    val kelvinTemperature = celsiusTemperature + 273.15
    return kelvinTemperature
}