import * as React from 'react';
import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { deleteApplicationById, getApplications } from '@/data/api';
import { revalidatePath } from 'next/cache';

export async function ApplicationList() {

    const appList = await getApplications();

    if (appList.length === 0) {
        return (
            <div>No applications found</div>
        )
    }

    async function handleDeleteApplication(form: FormData) {
        "use server";
        const id = form.get('id') as string;
        await deleteApplicationById(id);
        revalidatePath('/');
    }

    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell align="left">Company</TableCell>
                        <TableCell align="right">Position</TableCell>
                        <TableCell align="right">Applied</TableCell>
                        <TableCell align="right">Actions</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {appList.map((item) => (
                        <TableRow key={item.id}>
                            <TableCell component="th" scope="row">
                                {item.companyName}
                            </TableCell>
                            <TableCell align="right">{item.positionTitle}</TableCell>
                            <TableCell align="right">{item.appliedAt}</TableCell>
                            <TableCell align="right">
                                <form action={handleDeleteApplication}>
                                    <input type='hidden' name='id' value={item.id} />
                                    <Button type='submit'>Delete</Button>
                                </form>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}
