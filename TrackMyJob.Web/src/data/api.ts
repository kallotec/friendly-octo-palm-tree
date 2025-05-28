import axios from 'axios';
import { jobApplicationEntry } from './types';

axios.defaults.baseURL = (process.env.NODE_ENV === 'production' 
    ? process.env.services__webapi__https__0 
    : process.env.services__webapi__http__0);

export async function getMyApplications(): Promise<jobApplicationEntry[]> {
    try {
        const response = await axios.get<jobApplicationEntry[]>('api/applications');
        return response.data;
    } catch (error) {
        console.error('Login error:', error, axios.defaults.baseURL);
        return [];
    }
}
