import org.junit.jupiter.api.*
internal class IsNumberPerfectKtTest{
    @Test
    fun numberIsPerfect0(){
        val expected = true
        Assertions.assertEquals(expected, isNumberPerfect(28))
    }
    @Test
    fun numberIsPerfect1(){
        val expected = true
        Assertions.assertEquals(expected, isNumberPerfect(6))
    }
    @Test
    fun numberCannotBeZero(){
        assertThrows<IllegalArgumentException>{isNumberPerfect(0)}
    }
    @Test
    fun numberIsNotAPerfectNumber(){
        val expected = false
        Assertions.assertEquals(expected, isNumberPerfect(5))
    }
}