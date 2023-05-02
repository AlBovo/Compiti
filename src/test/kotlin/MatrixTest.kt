import org.junit.jupiter.api.*
class MatrixTest{
    @Test
    fun matrixLengthCannotBeNegative(){
        assertThrows<IllegalArgumentException>{ Matrix(-2, 4) }
    }
    @Test
    fun matrixHeightCannotBeNegative(){
        assertThrows<IllegalArgumentException>{ Matrix(2, -4) }
    }
    @Test
    fun initiallyTheMatrixHasValueEqualToZero(){
        val matrix = Matrix(4, 4)
        val expected = 0
        Assertions.assertEquals(matrix.get(3, 3), expected)
    }
    @Test
    fun set_theRowCannotBeGreaterThanLength(){
        val matrix = Matrix(4, 4)
        assertThrows<IllegalArgumentException>{ matrix.set(5, 3, 4) }
    }
    @Test
    fun set_theColumnCannotBeGreaterThanHeight(){
        val matrix = Matrix(4, 4)
        assertThrows<IllegalArgumentException>{ matrix.set(3, 5, 4) }
    }
    @Test
    fun set_theRowCannotBeLessThanZero(){
        val matrix = Matrix(4, 4)
        assertThrows<IllegalArgumentException>{ matrix.set(-1, 3, 3) }
    }
    @Test
    fun set_theColumnCannotBeLessThanZero(){
        val matrix = Matrix(4, 4)
        assertThrows<IllegalArgumentException>{ matrix.set(3, -1, 4) }
    }
    @Test
    fun set_worksCorrectly(){
        val matrix = Matrix(4, 4)
        matrix.set(3, 2, 3)
        val expected = 3
        Assertions.assertEquals(matrix.get(3, 2), expected)
    }
    @Test
    fun set_ifSwappingColumnAndRowValueIsDifferent(){
        val matrix = Matrix(4, 4)
        matrix.set(3, 2, 3)
        val expected = 0
        Assertions.assertEquals(matrix.get(2, 3), expected)
    }
    @Test
    fun get_worksCorrectly(){
        val matrix = Matrix(4, 4)
        matrix.set(2, 2, 1)
        val expected = 1
        Assertions.assertEquals(matrix.get(2, 2), expected)
    }
}