import org.junit.jupiter.api.*

class StringTest {
    @Test
    fun twoStringClassAreEqual(){
        val stringClassFirst = StringClass(arrayOf('4','f','2','4','r'))
        val stringClassSecond = StringClass(arrayOf('4','f','2','4','r'))
        val expected = true
        Assertions.assertEquals(expected, stringClassFirst.equalsTo(stringClassSecond))
    }
    @Test
    fun twoStringClassAreNotEqual(){
        val stringClassFirst = StringClass(arrayOf('4','f','2','4','r'))
        val stringClassSecond = StringClass(arrayOf('2','e','s','3','i'))
        val expected = false
        Assertions.assertEquals(expected, stringClassFirst.equalsTo(stringClassSecond))
    }
    @Test
    fun twoStringClassWithDifferentLengthAreNotEqual(){
        val stringClassFirst = StringClass(arrayOf('4','f','2','4','r'))
        val stringClassSecond = StringClass(arrayOf('4','f','2','4'))
        val expected = false
        Assertions.assertEquals(expected, stringClassFirst.equalsTo(stringClassSecond))
    }
    @Test
    fun trimWorksCorrectly(){
        val stringClass = StringClass(arrayOf(' ', ' ', 'f', ' ', 'f', ' ', ' '))
        val newStringClass = StringClass(stringClass.trim())
        val stringClassExpected = StringClass(arrayOf('f',' ', 'f'))
        val expected = true
        Assertions.assertEquals(expected, newStringClass.equalsTo(stringClassExpected))
    }
    @Test
    fun trimOnlySpacesStringWorksCorrectly(){
        val stringClass = StringClass(arrayOf(' ', ' ', ' ', ' ', ' ', ' ', ' '))
        val newStringClass = stringClass.trim()
        val expected = true
        Assertions.assertEquals(expected, newStringClass.isEmpty())
    }
    @Test
    fun trimWithNoSpacesDoNothing(){
        val stringClass = StringClass(arrayOf('8', '5', 'f', 'r', 'f', 'f', '2'))
        val newStringClass = StringClass(stringClass.trim())
        val stringClassExpected = StringClass(arrayOf('8', '5', 'f', 'r', 'f', 'f', '2'))
        val expected = true
        Assertions.assertEquals(expected, newStringClass.equalsTo(stringClassExpected))
    }
    @Test
    fun stringToIntIsCorrect(){
        val stringClass = StringClass(arrayOf('5','4','4','3'))
        val integer = stringClass.toInt()
        val expected = 5443
        Assertions.assertEquals(expected, integer)
    }
    @Test
    fun toIntCannotConvertNotIntegerChars(){
        val stringClass = StringClass(arrayOf('f','4','2','4'))
        assertThrows<IllegalStateException> { stringClass.toInt() }
    }
}