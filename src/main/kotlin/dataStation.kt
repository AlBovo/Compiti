class DataStation(array: Array<Int>){
    private val data = array
    init{
        require(array.isNotEmpty()){
            "The size of the array must be positive"
        }
    }
    fun max(): Int{
        var maxi = data[0]
        for(i in 1 until data.size){
            if(maxi < data[i]){
                maxi = data[i]
            }
        }
        return maxi
    }
    fun min(): Int{
        var mini = data[0]
        for(i in 1 until data.size){
            if(mini > data[i]){
                mini = data[i]
            }
        }
        return mini
    }
    fun media(): Double{
        var sum = 0
        for(i in 1 until data.size){
            sum += data[i]
        }
        return sum.toDouble()/data.size.toDouble()
    }
    fun distinct(): Array<Int>{
        val numbersFound = MutableList(0){0}
        for(i in data.indices){
            if(!numbersFound.contains(data[i])){
                numbersFound.add(data[i])
            }
        }
        return numbersFound.toTypedArray()
    }
    fun getOver(number: Int): Array<Int>{
        val numbersFound = MutableList(0){0}
        for(i in data.indices){
            if(data[i] > number){
                numbersFound.add(data[i])
            }
        }
        return numbersFound.toTypedArray()
    }
    fun getUnder(number: Int): Array<Int>{
        val numbersFound = MutableList(0){0}
        for(i in data.indices){
            if(data[i] < number){
                numbersFound.add(data[i])
            }
        }
        return numbersFound.toTypedArray()
    }
}