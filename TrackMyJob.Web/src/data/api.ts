import axios from 'axios';
import { jobApplicationEntry } from './types';

axios.defaults.baseURL = process.env.services__webapi__http__0;

export async function getApplications(): Promise<jobApplicationEntry[]> {
    try {
        const response = await axios.get<jobApplicationEntry[]>('api/applications');
        return response.data;
    } catch (error) {
        console.error(error);
        return [];
    }
}

export async function getApplicationById(id: string): Promise<jobApplicationEntry | null> {
    try {
        const response = await axios.get<jobApplicationEntry>(`api/applications/${id}`);
        return response.data;
    } catch (error) {
        console.error(error);
        return null;
    }
}

export async function deleteApplicationById(id: string): Promise<boolean> {
    try {
        const response = await axios.delete(`api/applications/${id}`);
        return (response.status == 204); // no content, if not found, 404 will return
    } catch (error) {
        console.error(error);
        return false;
    }
}
