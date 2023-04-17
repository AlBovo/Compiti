import kotlin.math.pow
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
fun calculateBMI(weightKG: Double, heightM: Double): String {
    require(weightKG > 0){
        "The weight cannot be negative or equal to 0"
    }
    require(heightM > 0){
        "The height cannot be negative or equal to 0"
    }
    val bmi: Double = weightKG/ heightM.pow(2)
    return if(bmi < 18.5) {
        "Underweight"
    } else if(bmi >= 18.5 && bmi < 25) {
        "Normal weight"
    } else {
        "Overweight"
    }
}