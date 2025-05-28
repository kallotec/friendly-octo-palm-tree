"use client";
import * as React from 'react';
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import { parseWithZod } from '@conform-to/zod';
import { useForm, getFormProps, getInputProps } from '@conform-to/react';
import { createApplicationFormSchema } from './CreateApplicationTypes';
import { handleCreateApplication } from './CreateApplicationFormHandlers';
import { useActionState } from 'react';
import { jobApplicationEntry } from '@/data/apitypes';

interface params {
    existing: jobApplicationEntry | undefined
}

export function CreateApplicationForm(p: params) {

    const isEditingExisting = p.existing !== undefined;
    const [lastResult, action] = useActionState(handleCreateApplication, undefined);
    const [form, fields] = useForm({
        lastResult,
        onValidate({ formData }) {
            return parseWithZod(formData, { schema: createApplicationFormSchema });
        },
        shouldValidate: 'onBlur',
        shouldRevalidate: 'onInput'
    });

    return (
        <Paper sx={{ margin: 1, padding: 1 }}>
            <Typography variant='h4'>
                {isEditingExisting ? 'Update' : 'Create'}
            </Typography>
            <form action={action} {...getFormProps(form)}>
                {p.existing?.id && (
                    <input type='hidden' name='id' value={p.existing.id} />
                )}
                <Box sx={{ margin: 1 }}>
                    <TextField margin='dense'
                        label="Company Name"
                        className={!fields.companyName.valid ? 'error' : ''}
                        {...getInputProps(fields.companyName, { type: 'text' })}
                        key={fields.companyName.key}
                    />
                    <div className="errors">{fields.companyName.errors}</div>
                </Box>
                <Box sx={{ margin: 1 }}>
                    <TextField
                        label="Position Title"
                        className={!fields.positionTitle.valid ? 'error' : ''}
                        {...getInputProps(fields.positionTitle, { type: 'text' })}
                        key={fields.positionTitle.key}
                    />
                    <div className="errors">{fields.positionTitle.errors}</div>
                </Box>
                <hr />
                <Button type='submit'>
                    {isEditingExisting ? 'Update' : 'Create'}
                </Button>
            </form>
        </Paper >
    )
}
