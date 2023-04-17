// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class NumberFraction(var numerator: Int, denominatorValue: Int){
    var denominator = denominatorValue
        set(value){
            require(value != 0){
                "The denominator must be different from 0"
            }
            field = value
        }
        init{
            require(denominatorValue != 0){
                "The denominator must be different from 0"
            }
        }
    fun product(number: NumberFraction): NumberFraction{
        val numberSecond = reduce(number)
        reduceCurrentFraction()
        return reduce(NumberFraction(numerator * numberSecond.numerator, denominator * numberSecond.denominator))
    }
    fun sum(number: NumberFraction): NumberFraction{
        val numberSecond = reduce(number)
        reduceCurrentFraction()
        return reduce(NumberFraction(numerator*numberSecond.denominator + numberSecond.numerator * denominator, denominator*numberSecond.denominator))
    }
    fun isEqual(number: NumberFraction): Boolean {
        val numberSecond = reduce(number)
        reduceCurrentFraction()
        return numerator == numberSecond.numerator && denominator == numberSecond.denominator
    }
    fun isPositive() = (denominator * numerator >= 0)
    fun calculateGCD(numberFirst: Int, numberSecond: Int): Int {
        require(numberSecond != 0){
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
    fun reduce(numberFraction: NumberFraction): NumberFraction{
        val gcd = calculateGCD(numberFraction.numerator, numberFraction.denominator)
        numberFraction.numerator /= gcd
        numberFraction.denominator /= gcd
        return numberFraction
    }
    fun reduceCurrentFraction(){
        val gcd = calculateGCD(numerator, denominator)
        numerator /= gcd
        denominator /= gcd
    }
}