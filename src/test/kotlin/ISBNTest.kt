import org.junit.jupiter.api.*

class ISBNTest{
    @Test
    fun numberCodeCannotHaveSizeGreaterOrLessThan9(){
        val numberCode = Array<Int>(10){ 0 }
        assertThrows<IllegalArgumentException> { ISBN(numberCode) }
    }
    @Test
    fun everyNumberInNumberCodeMustBeInRange0To9(){
        val numberCode = arrayOf(3, 2, 1, 4, 2, 6, 7, 2, 10)
        assertThrows<IllegalArgumentException> { ISBN(numberCode) }
    }
    @Test
    fun get_isbnIsValid(){
        val isbn = ISBN(arrayOf(3, 2, 1, 4, 2, 6, 7, 2, 6))
        val expected = "3214267264"
        Assertions.assertEquals(expected, isbn.get())
    }
}