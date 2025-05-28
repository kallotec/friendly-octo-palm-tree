
import { z } from 'zod';

export const createApplicationFormSchema = z.object({
    companyName: z.string().min(3),
    positionTitle: z.string().min(3),
});