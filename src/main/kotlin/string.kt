class StringClass(strings: Array<Char>){
    var string: Array<Char> = arrayOf(' ')
        private set
    init{
        string = strings
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
    fun trim(): StringClass{
        var positionFirst = 0
        var positionSecond = 0
        val array = MutableList<Char>(0){' '}
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
        for(i in positionFirst..positionSecond){
            array.add(string[i])
        }
        return StringClass(array.toTypedArray())
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