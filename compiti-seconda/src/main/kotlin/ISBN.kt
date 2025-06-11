class ISBN(numberCode: Array<Int>){
    private val isbn = Array<Int>(10){ 0 }
    init{
        require(numberCode.size == 9){
            "The numberCode size must be 9"
        }
        var total = 0
        var counter = 10
        for(i in numberCode.indices){
            require(numberCode[i] in 0..9){
                "Every number must be in the range from 0 to 9"
            }
            total += numberCode[i] * counter
            counter--
            isbn[i] = numberCode[i]
        }
        for(i in 0..10){
            if((total + i) % 11 == 0){
                isbn[9] = i
            }
        }
    }
    fun get(): Array<Char>{
        var newISBN = Array(10){ ' ' }
        for(i in isbn.indices){
            if(i == 9){
                newISBN[i] = if(isbn[i] == 10) 'X' else isbn[i].digitToChar()
            }
            else{
                newISBN[i] = isbn[i].digitToChar()
            }
        }
        return newISBN
    }
}