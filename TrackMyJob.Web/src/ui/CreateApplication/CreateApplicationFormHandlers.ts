"use server";
import { parseWithZod } from "@conform-to/zod";
import { createApplicationFormSchema } from "./CreateApplicationTypes";
import { jobApplicationEntry } from "@/data/apitypes";
import { createApplication } from "@/data/api";
import { redirect } from "next/navigation";

export async function handleCreateApplication(_: any, formData: FormData) {
    
    console.log('submitted!', formData);

    const submission = parseWithZod(formData, {
        schema: createApplicationFormSchema,
    });

    if (submission.status !== 'success') {
        console.log('failed!', formData);
        return submission.reply();
    }

    const newApp: jobApplicationEntry = {
        id: undefined,
        appliedAt: undefined,
        ...submission.value,
    };

    await createApplication(newApp);
    redirect('/');
}