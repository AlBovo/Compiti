import org.junit.jupiter.api.*
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
internal class IsPromotedKtTest{

    @Test
    fun cannotHaveBothNegativeValue(){
        assertThrows<IllegalArgumentException>{isPromoted(-1,-2)}
    }

    @Test
    fun cannotHaveNegativeInsufficiency(){
        assertThrows<IllegalArgumentException>{isPromoted(-1,32)}
    }

    @Test
    fun cannotHaveNegativeDebits(){
        assertThrows<IllegalArgumentException>{isPromoted(32,1)}
    }

    @Test
    fun cannotHaveGreaterInsufficiency(){
        val expected = false
        Assertions.assertEquals(expected, isPromoted(4,4))
    }

    @Test
    fun canHaveEqualToThreeInsufficiency(){
        val expected = true
        Assertions.assertEquals(expected, isPromoted(3,3))
    }

    @Test
    fun canHaveBothZeroValue(){
        val expected = true
        Assertions.assertEquals(expected, isPromoted(0,0))
    }

    @Test
    fun cannotHaveGreaterDebits(){
        assertThrows<IllegalArgumentException>{isPromoted(2, 11)}
    }

    @Test
    fun canHaveBothPositiveNumber(){
        val expected = true
        Assertions.assertEquals(expected, isPromoted(2, 4))
    }

    @Test
    fun cannotHaveGreaterInsufficiency2(){
        val expected = false
        Assertions.assertEquals(expected, isPromoted(4,4))
    }

    @Test
    fun cannotHaveGreaterInsufficiency3(){
        val expected = false
        Assertions.assertEquals(expected, isPromoted(4,3))
    }
}