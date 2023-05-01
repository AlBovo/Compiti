class StringClass(val string: Array<Char>){
    init{
        check(string.isNotEmpty()){
            "The string cannot be empty"
        }
    }
    fun equalsTo(stringParameter: StringClass): Boolean{
        if(stringParameter.string.size == string.size){
            for(i in string.indices){
                if(string[i] != stringParameter.string[i]){
                    return false
                }
            }
            return true
        }
        return false
    }
    fun trim(): Array<Char>{
        var positionFirst = -1
        var positionSecond = -1
        for(i in string.indices){
            if(string[i] != ' '){
                positionFirst = i
                break
            }
        }
        for(i in string.size-1 downTo 0){
            if(string[i] != ' '){
                positionSecond = i
                break
            }
        }
        if(positionFirst == -1 && positionSecond == -1){
            return Array(0){' '}
        }
        val array = Array<Char>(positionSecond - positionFirst + 1){' '}
        for(i in positionFirst..positionSecond){
            array[i-positionFirst] = string[i]
        }
        return array
    }
    fun toInt(): Int{
        for(i in string.indices){
            check(string[i] in '0'..'9')
        }
        var total = 0
        for(i in string.indices){
            total += (string[i]-'0')*fastExp(10, string.size-i)
        }
        return total/10
    }
    private fun fastExp(base: Int, exp: Int): Int{
        if(exp == 0){ return 1 }
        if(exp == 1){ return base }
        val tot = fastExp(base, exp/2)
        return if(exp % 2 == 0){
            tot * tot
        } else{
            tot * tot * base
        }
    }
}