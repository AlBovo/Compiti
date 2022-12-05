import org.junit.jupiter.api.*

internal class TemperatureConverterKtTest {
    @Test
    fun cannotConvertUnderAbsoluteZeroTemperature(){
        assertThrows<IllegalArgumentException> {celsiusToKelvinTemperature(-273.16)}
    }

    @Test
    fun canConvertAbsoluteZeroTemperature(){
        val expected = 0.0
        Assertions.assertEquals(expected, celsiusToKelvinTemperature(-273.15))
    }

    @Test
    fun canConvertZeroTemperature(){
        val expected = 273.15
        Assertions.assertEquals(expected, celsiusToKelvinTemperature(0.0))
    }
}