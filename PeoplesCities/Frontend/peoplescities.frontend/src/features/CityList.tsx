import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateCityDto, Client, CityLookupDto } from '../api/api';
import { FormControl } from 'react-bootstrap';

const apiClient = new Client('https://localhost:7247');


async function createCity(city: CreateCityDto) {
    await apiClient.create('1.0', city);
    console.log('City is created.');
}

const CityList: FC<{}> = (): ReactElement => {
    let textInput = useRef(null);
    const [cities, setCities] = useState<CityLookupDto[] | undefined>(undefined);

    async function getCities() {
        const cityListVm = await apiClient.getAll('1.0');
        setCities(cityListVm.cities);
    }

    useEffect(() => {
        setTimeout(getCities, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const city: CreateCityDto = {
                name: event.currentTarget.value,
                description: ""
            };
            createCity(city);
            event.currentTarget.value = '';
            setTimeout(getCities, 500);
        }
    };

    return (
        <div>
            Cities
            <div>
                <FormControl ref={textInput} onKeyPress={handleKeyPress} />
            </div>
            <section>
                {cities?.map((city) => (
                    <div>{city.name}</div>
                ))}
            </section>
        </div>
    );
};
export default CityList;