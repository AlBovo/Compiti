import org.junit.jupiter.api.*

class CalculateMCDKtTest{
    @Test
    fun numberCannotBeNegative(){
        assertThrows<IllegalArgumentException> { calculateGCD(-4, 3) }
    }

    @Test
    fun numberCannotBeNegative2(){
        assertThrows<IllegalArgumentException> { calculateGCD(4, -1) }
    }

    @Test
    fun numbersCannotBeBothNegative(){
        assertThrows<IllegalArgumentException> { calculateGCD(-4, -10) }
    }

    @Test
    fun numberCanBePositive(){
        val expected = 4
        Assertions.assertEquals(expected, calculateGCD(4,16))
    }

    @Test
    fun numberCanHaveNoValueInCommon(){
        val expected = 1
        Assertions.assertEquals(expected, calculateGCD(3, 5))
    }
}