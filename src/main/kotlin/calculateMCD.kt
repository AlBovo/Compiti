// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
fun calculateGCD(numberFirst: Int, numberSecond: Int): Int{
    require(numberFirst > 0 && numberSecond > 0){
        "The number must be positive"
    }
    var numberFirst1 = numberFirst
    var numberSecond1 = numberSecond
    var numberMaximum = if(numberFirst > numberSecond) numberFirst else numberSecond
    var gcd = 1
    for(i in 2..numberMaximum){
        if(numberFirst1 == 1 && numberSecond1 == 1){
            break
        }
        while(numberFirst1%i == 0 && numberSecond1%i == 0){
            gcd *= i
            numberFirst1 /= i
            numberSecond1 /= i
        }
    }
    return gcd
}