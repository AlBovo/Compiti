import kotlin.math.abs
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
fun calculateSquareOfNumber(number: Int): Int{
    require(number != 0){
        "The number must be different from 0"
    }
    var square = 1
    var counter = 1
    for(i in 1 until abs(number)){
        counter += 2
        square += counter
        println(i+2)
    }
    return square
}