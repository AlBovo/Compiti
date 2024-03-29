import org.junit.jupiter.api.*
internal class FindIfItsPrimeKtTest{
    @Test
    fun itsPrime(){
        val expected = true
        Assertions.assertEquals(expected, findIfItsPrime(17))
    }
    @Test
    fun itsNotPrime(){
        val expected = false
        Assertions.assertEquals(expected, findIfItsPrime(8))
    }
    @Test
    fun cannotHaveNegativeValue(){
        assertThrows<IllegalArgumentException>{findIfItsPrime(-14)}
    }
}