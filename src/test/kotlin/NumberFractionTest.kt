import org.junit.jupiter.api.*

class NumberFractionTest{
    @Test
    fun cannotHaveZeroDenominator(){
        assertThrows<IllegalArgumentException> { NumberFraction(3, 0) }
    }

    @Test
    fun canHaveEveryPossibleProduct(){
        val expected = 55
        val expectedSecond = 32
        val number = NumberFraction(11, 8)
        val numberSecond = NumberFraction(5, 4)
        val numberThird = number.product(numberSecond)
        Assertions.assertEquals(expected, numberThird.numerator)
        Assertions.assertEquals(expectedSecond, numberThird.denominator)
    }

    @Test
    fun canHaveNegativeNumerator(){
        val expected = -55
        val expectedSecond = 32
        val number = NumberFraction(-11, 8)
        val numberSecond = NumberFraction(5, 4)
        val numberThird = number.product(numberSecond)
        Assertions.assertEquals(expected, numberThird.numerator)
        Assertions.assertEquals(expectedSecond, numberThird.denominator)
    }

    @Test
    fun canHaveNegativeDenominator(){
        val expected = 55
        val expectedSecond = -32
        val number = NumberFraction(11, 8)
        val numberSecond = NumberFraction(5, -4)
        val numberThird = number.product(numberSecond)
        Assertions.assertEquals(expected, numberThird.numerator)
        Assertions.assertEquals(expectedSecond, numberThird.denominator)
    }

    @Test
    fun canHavePositiveSum(){
        val expected = 20
        val expectedSecond = 8
        val number = NumberFraction(4, 2)
        val numberSecond = NumberFraction(2, 4)
        val numberThird = number.sum(numberSecond)
        Assertions.assertEquals(expected, numberThird.numerator)
        Assertions.assertEquals(expectedSecond, numberThird.denominator)
    }

    @Test
    fun canHaveNegativeSum(){
        val expected = -20
        val expectedSecond = 8
        val number = NumberFraction(-4, 2)
        val numberSecond = NumberFraction(-2, 4)
        val numberThird = number.sum(numberSecond)
        Assertions.assertEquals(expected, numberThird.numerator)
        Assertions.assertEquals(expectedSecond, numberThird.denominator)
    }

    @Test
    fun canHaveZeroNumerator(){
        val expected = 0
        val expectedSecond = 8
        val number = NumberFraction(0, 2)
        val numberSecond = NumberFraction(0, 4)
        val numberThird = number.sum(numberSecond)
        Assertions.assertEquals(expected, numberThird.numerator)
        Assertions.assertEquals(expectedSecond, numberThird.denominator)
    }
}