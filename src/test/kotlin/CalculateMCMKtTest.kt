import org.junit.jupiter.api.*
class CalculateMCMKtTest{
    @Test
    fun singleValueCannotBeZero(){
        assertThrows<IllegalArgumentException> {calculateMCM(0, 10)}
    }

    @Test
    fun singleValueCannotBeZero2(){
        assertThrows<IllegalArgumentException> {calculateMCM(10,0)}
    }

    @Test
    fun bothValuesCannotBeZero(){
        assertThrows<IllegalArgumentException> {calculateMCM(0, 0)}
    }

    @Test
    fun numberCannotBeLowerThanZero(){
        assertThrows<IllegalArgumentException> {calculateMCM(-10, 32)}
    }

    @Test
    fun numbersMustBeBothPositive(){
        var expected = 230
        Assertions.assertEquals(expected, calculateMCM(23, 10))
    }

    @Test
    fun numberCannotBeBothZeroAndNegative(){
        assertThrows<IllegalArgumentException> {calculateMCM(-10, 0)}
    }

    @Test
    fun bothNumbersArePrime() {
        var expected = 35
        Assertions.assertEquals(expected, calculateMCM(5, 7))
    }

    @Test
    fun bothNumbersAreEquals(){
        var expected = 42
        Assertions.assertEquals(expected, calculateMCM(42, 42))
    }
}