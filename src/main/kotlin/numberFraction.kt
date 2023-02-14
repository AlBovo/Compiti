import java.awt.font.NumericShaper

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
    fun product(numberSecond: NumberFraction) = NumberFraction(numerator * numberSecond.numerator, denominator * numberSecond.denominator).reduce()
    fun sum(numberSecond: NumberFraction) = NumberFraction(numerator*numberSecond.denominator + numberSecond.numerator * denominator, denominator*numberSecond.denominator).reduce()
    fun isPositive() = (denominator * numerator >= 0)
    fun isEqual(numberSecond: NumberFraction) = (numerator == numberSecond.numerator && denominator == numberSecond.denominator)
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
    fun reduce(): NumberFraction{
        val gcd = calculateGCD(numerator, denominator)
        numerator /= gcd
        denominator /= gcd
        return NumberFraction(numerator, denominator)
    }
}