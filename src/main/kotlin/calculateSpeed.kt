fun calculateSpeed(distanceInMeter: Double, timeInSecond: Double): Double{
    require(distanceInMeter > 0){
        "Distance cannot be lower or equal to 0"
    }
    require(timeInSecond > 0){
        "Time cannot be lower or equal to 0"
    }
    val speedInMeterPerSecond = timeInSecond * distanceInMeter
    return speedInMeterPerSecond
}