import org.junit.jupiter.api.*
class AccountTest {
    // tre fasi di test: creare ambiente(account), invocare la funzione e confrontare ciò che ci aspettiamo
    @Test
    fun whenWeCreateAnAccountTheBalanceIsZero() {
        val account = Account()
        val expected = 0.0
        Assertions.assertEquals(account.balance, expected)
    }

    @Test
    fun whenWeCreateAnAccountTheNameIsEmpty(){
        val account = Account()
        val expected = ""
        Assertions.assertEquals(account.name, expected)
    }

    @Test
    fun cannotHaveNegativeBalance(){
        val account = Account()
        assertThrows<IllegalArgumentException>{account.balance = -0.000000001}
    }

    @Test
    fun whenSetNamePippoTheNameIsPippo(){
        var account = Account()
        account.name = "Pippo"
        val expected = "Pippo"
        Assertions.assertEquals(account.name, expected)
    }

    @Test
    fun whenSetBalanceTo100EURTheBalanceIs100EUR(){
        var account = Account()
        account.balance = 100.0
        val expected = 100.0
        Assertions.assertEquals(account.balance, expected)
    }

}