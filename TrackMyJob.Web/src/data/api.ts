import axios from 'axios';
import { jobApplicationEntry } from './types';
const apiBaseUrl:string = process.env['services__webapi__https__0'] ?? process.env['services__webapi__http__0'] ?? 'invaliduri';

export async function getMyApplications(): Promise<jobApplicationEntry[]> {
    try {
        axios.defaults.baseURL = apiBaseUrl;
        console.log(axios.defaults.baseURL);
        const response = await axios.get<jobApplicationEntry[]>('/applications');
        return response.data;
    } catch (error) {
        console.error('Login error:', error, axios.defaults.baseURL);
        return [];
    }
}
