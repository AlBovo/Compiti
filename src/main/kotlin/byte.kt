// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class Byte(private val byte: Array<Int>){
    init{
        require(byte.size == 8){
            "A byte must contains 8 bit"
        }
        for(i in 0..7){
            require(byte[i] == 0 || byte[i] == 1){
                "A bit can only be 0 or 1"
            }
        }
        byte.reverse()
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
    fun sum(secondByte: Array<Int>): Int = toIntPrivate(secondByte) + toIntPrivate(byte)
    fun isOdd(): Boolean = byte[0] == 1

    private fun toIntPrivate(secondByte: Array<Int>): Int{
        var value = 0
        var powValue = 1
        for(i in 0..7){
            value += secondByte[i] * powValue
            powValue *= 2
        }
        return value
    }
}