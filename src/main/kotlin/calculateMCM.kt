fun calculateMCM(numberFirstVal: Int, numberSecondVal: Int): Int {
    require(numberFirstVal > 0 && numberSecondVal > 0){
        "Both numbers must be different from 0"
    }
    var numberFirst = numberFirstVal
    var numberSecond = numberSecondVal
    val numberMaximum = if(numberFirst > numberSecond){
        numberFirst
    }else{
        numberSecond
    }
    var gcd = 1
    for(i in 2..numberMaximum){
        if(numberFirst == 1 && numberSecond == 1){
            break
        }
        while(numberFirst%i == 0 && numberSecond%i == 0){
            gcd *= i
            numberFirst /= i
            numberSecond /= i
        }
    }
    return (numberFirstVal * numberSecondVal)/gcd
}