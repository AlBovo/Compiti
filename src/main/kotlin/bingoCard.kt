class BingoCard(private val listCardByRow: Array<Int>){
    private var numberExtracted = Array<Boolean>(91) { false }
    init{
        require(listCardByRow.size == 15){
            "The size of the card it's not correct"
        }
        require(listCardByRow.size == listCardByRow.distinct().size){
            "You must enter a card with only distinct numbers"
        }
    }
    fun isWon(){

    }
    fun extractNumber(numberExtracted: Int){

    }
}