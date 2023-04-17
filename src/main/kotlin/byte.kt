class Byte(val byte: Array<Int>){
    init{
        require(byte.size == 8){
            "A byte must contains 8 bit"
        }
        for(i in 0..7){
            require(byte[i] == 0 || byte[i] == 1){
                "A bit can only be 0 or 1"
            }
        }
    }
    fun toInt(): Int{
        var value = 0
        var powValue = 1
        for(i in 0..7){
            value += byte[i] * powValue
            powValue *= 2
        }
        return value
    }
    fun sum(secondByte: Byte): Byte {
        val thirdByte = arrayOf(0, 0, 0, 0, 0, 0, 0, 0)
        var carry = 0
        for(i in 7 downTo 0){
            thirdByte[i] += (byte[i] + secondByte.byte[i] + carry) % 2
            carry = (byte[i] + secondByte.byte[i]) / 2
        }
        check(carry == 0) {
            "Error Overflow"
        }
        return Byte(thirdByte)
    }
    fun isOdd(): Boolean = byte[0] == 1
}