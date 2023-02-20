import org.junit.jupiter.api.*

internal class NumberFractionTest{
    @Test
    fun cannotHaveZeroDenominator(){
        assertThrows<IllegalArgumentException> { NumberFraction(3, 0) }
    }

    @Test
    fun cannotChangeDenominatorValueToZero(){
        assertThrows<IllegalArgumentException> {
            var number = NumberFraction(4, 2)
            number.denominator = 0
        }
    }

    @Test
    fun canHavePositiveProduct(){
        val expected = true
        val number = NumberFraction(11, 8)
        val numberSecond = NumberFraction(5, 4)
        val numberThird = number.product(numberSecond)
        Assertions.assertEquals(expected, numberThird.isEqual(NumberFraction(55, 32)))
    }

    @Test
    fun canHaveNegativeNumerator(){
        val expected = true
        val number = NumberFraction(-11, 8)
        val numberSecond = NumberFraction(5, 4)
        val numberThird = number.product(numberSecond)
        Assertions.assertEquals(expected, numberThird.isEqual(NumberFraction(-55, 32)))
    }

    @Test
    fun canHaveNegativeDenominator(){
        val expected = true
        val number = NumberFraction(11, 8)
        val numberSecond = NumberFraction(5, -4)
        val numberThird = number.product(numberSecond)
        Assertions.assertEquals(expected, numberThird.isEqual(NumberFraction(55, -32)))
    }

    @Test
    fun canHavePositiveSum(){
        val expected = true
        val number = NumberFraction(4, 2)
        val numberSecond = NumberFraction(2, 4)
        val numberThird = number.sum(numberSecond)
        Assertions.assertEquals(expected, numberThird.isEqual(NumberFraction(5, 2)))
    }

    @Test
    fun canHaveNegativeSum(){
        val expected = true
        val number = NumberFraction(-4, 2)
        val numberSecond = NumberFraction(-2, 4)
        val numberThird = number.sum(numberSecond)
        Assertions.assertEquals(expected, numberThird.isEqual(NumberFraction(-5, 2)))
    }

    @Test
    fun canHaveZeroNumerator(){
        val expected = true
        val number = NumberFraction(0, 2)
        val numberSecond = NumberFraction(0, 4)
        val numberThird = number.sum(numberSecond)
        Assertions.assertEquals(expected, numberThird.isEqual(NumberFraction(0, 1)))
    }

    @Test
    fun canHavePositiveFraction(){
        val expected = true
        val number = NumberFraction(3, 1)
        Assertions.assertEquals(expected, number.isPositive())
    }

    @Test
    fun canHaveNegativeFraction(){
        val expected = false
        val number = NumberFraction(-4, 1)
        Assertions.assertEquals(expected, number.isPositive())
    }

    @Test
    fun numbersAreEquals(){
        val expected = true
        val number = NumberFraction(8, 16)
        val secondNumber = NumberFraction(1, 2)
        number.reduceCurrentFraction()
        Assertions.assertEquals(expected, number.isEqual(secondNumber))
    }

    @Test
    fun numbersArentEquals(){
        val expected = false
        val number = NumberFraction(3, 15)
        val secondNumber = NumberFraction(1, 6)
        number.reduceCurrentFraction()
        Assertions.assertEquals(expected, number.isEqual(secondNumber))
    }
}