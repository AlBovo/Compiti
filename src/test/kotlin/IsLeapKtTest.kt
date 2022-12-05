import org.junit.jupiter.api.*

internal class IsLeapKtTest{
    @Test
    fun canHavePositiveLeapYear(){
        val expected = true
        Assertions.assertEquals(expected, isLeap(2020))
    }

    @Test
    fun canHaveNegativeLeapYear(){
        val expected = true
        Assertions.assertEquals(expected, isLeap(-2024))
    }

    @Test
    fun canHavePositiveNotLeapYear(){
        val expected = false
        Assertions.assertEquals(expected, isLeap(2021))
    }

    @Test
    fun canHaveNegativeNotLeapYear(){
        val expected = false
        Assertions.assertEquals(expected, isLeap(-3))
    }
}