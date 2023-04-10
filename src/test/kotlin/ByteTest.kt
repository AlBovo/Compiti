import org.junit.jupiter.api.*

class ByteTest{
    @Test
    fun byteLengthCannotBeGreaterThan8(){
        val byte = Array<Int>(9){1}
        assertThrows<IllegalArgumentException> { Byte(byte) }
    }
    @Test
    fun byteLengthCannotBeLowerThan8(){
        val byte = Array<Int>(7){0}
        assertThrows<IllegalArgumentException> { Byte(byte) }
    }
    @Test
    fun byteMustOnlyContains0or1(){
        val byte = Array<Int>(8){3}
        assertThrows<IllegalArgumentException> { Byte(byte) }
    }
    @Test
    fun toIntIsCorrect(){
        val byte = Byte(arrayOf(0, 1, 1, 0, 1, 0, 1, 0)) // 01101010
        val expected = 106
        Assertions.assertEquals(expected, byte.toInt())
    }
    @Test
    fun byteIsOdd(){
        val byte = Byte(arrayOf(1, 1, 1, 0, 1, 0, 1, 1)) // 01101010
        val expected = true
        Assertions.assertEquals(expected, byte.isOdd())
    }
    @Test
    fun byteIsNotOdd(){
        val byte = Byte(arrayOf(0, 1, 1, 0, 1, 0, 1, 0)) // 01101010
        val expected = false
        Assertions.assertEquals(expected, byte.isOdd())
    }
    @Test
    fun sumOfTwoEqualsBytesIsCorrect(){
        val firstByte = Byte(arrayOf(0, 1, 1, 0, 1, 0, 1, 0)) // 01101010
        val secondByte = arrayOf(0, 1, 1, 0, 1, 0, 1, 0) // 01101010
        secondByte.reverse()
        val expected = 212
        Assertions.assertEquals(expected, firstByte.sum(secondByte))
    }
    @Test
    fun sumOfTwoDifferentBytesIsCorrect(){
        val firstByte = Byte(arrayOf(0, 1, 1, 0, 1, 0, 1, 0)) // 01101010
        val secondByte = arrayOf(0, 1, 1, 0, 1, 0, 1, 1) // 01101011
        secondByte.reverse()
        val expected = 213
        Assertions.assertEquals(expected, firstByte.sum(secondByte))
    }
}