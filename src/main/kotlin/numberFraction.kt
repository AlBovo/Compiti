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
    fun product(numberSecond: NumberFraction) = NumberFraction(numerator * numberSecond.numerator, denominator * numberSecond.denominator)
    fun sum(numberSecond: NumberFraction) = NumberFraction(numerator*numberSecond.denominator + numberSecond.numerator * denominator, denominator*numberSecond.denominator)
    fun isPositive() = (denominator * numerator >= 0)
    fun isEqual(numberSecond: NumberFraction) = (numerator == numberSecond.numerator && denominator == numberSecond.denominator)
}