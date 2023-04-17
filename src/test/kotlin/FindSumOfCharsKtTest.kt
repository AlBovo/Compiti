import org.junit.jupiter.api.*
import kotlin.math.exp
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
internal class FindSumOfCharsKtTest{
    @Test
    fun canHaveEveryNumber(){
        val expected = 11
        Assertions.assertEquals(expected, findSumOfChars(452))
    }

    @Test
    fun canHaveNegativeValue(){
        val expected = 5
        Assertions.assertEquals(expected, findSumOfChars(-311))
    }

    @Test
    fun canHaveZeroValue(){
        val expected = 0
        Assertions.assertEquals(expected, findSumOfChars(0))
    }
}