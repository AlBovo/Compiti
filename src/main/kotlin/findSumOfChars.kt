import kotlin.math.abs
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
fun findSumOfChars(number: Int): Int{
    var sum = 0
    var tempNumber = number
    while(tempNumber != 0){
        sum += tempNumber % 10
        tempNumber /= 10
    }
    return abs(sum)
}