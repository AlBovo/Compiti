import org.junit.jupiter.api.*
internal class CalculateSquareOfNumberKtTest{
    @Test
    fun cannotHaveNegativeValue(){
        assertThrows<IllegalArgumentException>{calculateSquareOfNumber(0)}
    }
    @Test
    fun canHavePositiveNumber(){
        val expected = 49
        Assertions.assertEquals(expected, calculateSquareOfNumber(7))
    }
    @Test
    fun canHaveNegativeValue(){
        val expected = 49
        Assertions.assertEquals(expected, calculateSquareOfNumber(-7))
    }
}