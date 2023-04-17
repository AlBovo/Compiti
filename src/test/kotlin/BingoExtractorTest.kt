import org.junit.jupiter.api.*
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class BingoExtractorTest{
    @Test
    fun atTheStartTheBagMustNotBeEmpty(){
        val bingo = Bingo()
        val expected = false
        Assertions.assertEquals(expected, bingo.isEmpty())
    }
    @Test
    fun cannotExtractTwoTimesTheSameNumber(){
        val bingo = Bingo()
        val expected = true
        for(i in 1..90){
            var temp = bingo.extractNumber()
        }
        Assertions.assertEquals(expected, bingo.isEmpty())
    }
    @Test
    fun cannotExtract91Numbers(){
        val bingo = Bingo()
        val expected = true
        for(i in 1..91){
            if(i == 91){
                assertThrows<IllegalArgumentException> { var temp = bingo.extractNumber() }
            }
            else {
                var temp = bingo.extractNumber()
            }
        }
    }
}