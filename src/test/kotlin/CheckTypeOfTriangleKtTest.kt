import org.junit.jupiter.api.*

internal class CheckTypeOfTriangleKtTest{
    @Test
    fun cannotHaveAllNegative(){
        assertThrows<IllegalArgumentException>{checkTypeOfTriangle(-1.0, -1.0,-1.0)}
    }

    @Test
    fun cannotHaveTwoNegative(){
        assertThrows<IllegalArgumentException>{checkTypeOfTriangle(-2.0, -2.0, 32.0)}
    }

    @Test
    fun cannotHaveSingleNegative(){
        assertThrows<IllegalArgumentException>{checkTypeOfTriangle(-1.0,3.0,4.0)}
    }

    @Test
    fun canHaveEquilateralTriangle(){
        val expected = 1
        Assertions.assertEquals(expected, checkTypeOfTriangle(1.0, 1.0, 1.0))
    }

    @Test
    fun canHaveScaleneTriangle(){
        val expected = 2
        Assertions.assertEquals(expected, checkTypeOfTriangle(2.0, 1.0, 3.0))
    }

    @Test
    fun canHaveIsoscelesTriangle1(){
        val expected = 3
        Assertions.assertEquals(expected, checkTypeOfTriangle(2.0, 2.0, 3.0))
    }

    @Test
    fun canHaveIsoscelesTriangle2(){
        val expected = 3
        Assertions.assertEquals(expected, checkTypeOfTriangle(2.0, 3.0, 2.0))
    }

    @Test
    fun canHaveIsoscelesTriangle3(){
        val expected = 3
        Assertions.assertEquals(expected, checkTypeOfTriangle(2.0, 3.0, 3.0))
    }
}