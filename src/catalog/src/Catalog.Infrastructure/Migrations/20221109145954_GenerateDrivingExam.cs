using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    public partial class GenerateDrivingExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "35531282-6772-413c-99a0-57c8a7059c49",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "687e87df-d57a-4578-86df-3dc1938bfabb",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "c765cb93-f518-45ca-8372-0aa288f9d5b3",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "d079864f-2995-4357-8d3f-2784a1bffd23",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.InsertData(
                schema: "cat",
                table: "exams",
                columns: new[] { "id", "code", "created_by", "created_date", "default_question_number", "deleted", "deleted_date", "description", "hide_result", "last_modified_by", "last_modified_date", "minus_score_per_question", "name", "percentage_to_pass", "plus_score_per_question", "show_all_question", "shuffling_exams", "time_per_question", "view_next_question", "view_pass_question" },
                values: new object[,]
                {
                    { "2bacd63b-a302-42e9-acf8-8eb165a5e135", "2bacd63b-a302-42e9-acf8-8eb165a5e135", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3447), 30, null, null, "Level B1 Driving Test", false, null, null, 0, "Level B1 Driving Test", 90, 0, false, 0, 0, false, false },
                    { "3a6e1576-43af-4dde-b894-27f28d460084", "3a6e1576-43af-4dde-b894-27f28d460084", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3468), 45, null, null, "Level D Driving Test", false, null, null, 0, "Level D Driving Test", 91, 0, false, 0, 0, false, false },
                    { "3cc9c957-c7a1-455e-ad88-43e8f6157695", "3cc9c957-c7a1-455e-ad88-43e8f6157695", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3479), 45, null, null, "Level F Driving Test", false, null, null, 0, "Level F Driving Test", 91, 0, false, 0, 0, false, false },
                    { "4311838a-c6b2-467c-836d-0237bb196cbe", "4311838a-c6b2-467c-836d-0237bb196cbe", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3463), 40, null, null, "Level C Driving Test", false, null, null, 0, "Level C Driving Test", 90, 0, false, 0, 0, false, false },
                    { "45959950-fcab-4793-b1ce-422d102aa50b", "45959950-fcab-4793-b1ce-422d102aa50b", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3474), 45, null, null, "Level E Driving Test", false, null, null, 0, "Level E Driving Test", 91, 0, false, 0, 0, false, false },
                    { "46a4af13-d57a-4dab-9cfa-2247be54be4a", "46a4af13-d57a-4dab-9cfa-2247be54be4a", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3457), 35, null, null, "Level B2 Driving Test", false, null, null, 0, "Level B2 Driving Test", 91, 0, false, 0, 0, false, false },
                    { "5bf3cd2b-40f2-41f0-804f-1febe6d25863", "5bf3cd2b-40f2-41f0-804f-1febe6d25863", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3441), 25, null, null, "Level A4 Driving Test", false, null, null, 0, "Level A4 Driving Test", 92, 0, false, 0, 0, false, false },
                    { "86f6bf50-a466-4ae8-a1f4-7bfbaf8b0e96", "86f6bf50-a466-4ae8-a1f4-7bfbaf8b0e96", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3430), 25, null, null, "Level A2 Driving Test", false, null, null, 0, "Level A2 Driving Test", 92, 0, false, 0, 0, false, false },
                    { "ec00060f-ef87-47d8-8ddc-873d2aa81add", "ec00060f-ef87-47d8-8ddc-873d2aa81add", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3436), 25, null, null, "Level A3 Driving Test", false, null, null, 0, "Level A3 Driving Test", 92, 0, false, 0, 0, false, false },
                    { "f46d018a-63c3-4e83-a7e9-b381dcae9cd1", "f46d018a-63c3-4e83-a7e9-b381dcae9cd1", null, new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(3420), 25, null, null, "Level A1 Driving Test", false, null, null, 0, "Level A1 Driving Test", 84, 0, false, 0, 0, false, false }
                });

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "0293d928-8ec7-4bf7-82cf-894235220294",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "7b70ddba-b8b0-42f8-961e-20785f0f564b",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(5484));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "999abd49-0b6d-4fd0-81f4-0a419b71bac8",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "abdbeff3-9840-4200-a8c6-e1f1e3d0c428",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "c363cdf9-cadb-4090-a03d-43c4f5303e9b",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "d3dd9e4d-0170-45ce-9ee2-78b9f8770e38",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(5499));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "01fd1f9c-78c4-41b1-a379-1229eba16808",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "33ae4edc-9bc7-4201-afda-28d5cfa4e84e",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "42fe49d6-44f9-4006-af32-88f20c315023",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(6179));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "6f01c413-497a-4745-93d4-4e41d254fdad",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questions",
                keyColumn: "id",
                keyValue: "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 802, DateTimeKind.Utc).AddTicks(8614));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "056d3522-078a-4d46-9262-d56ea7e557ea",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(408));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "244b45f1-fca2-4c6b-9a1f-71d7e44919c5",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(500));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "64f5b16d-5656-4418-8b40-7cb4c972bdd4",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(424));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "77f517bd-1855-4e0a-ac49-6893a707520c",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(402));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "7c99c1ee-a1c8-4e1b-a9a4-a174760e6dc2",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(405));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "80f521b3-c1d8-42ad-8c04-8e3d93e56fbe",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "b523c423-79c9-4d29-82ee-aec0ee4db213",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "b97ae130-8c1c-42b6-a47c-4e5e1fc056b6",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "bedbcaa0-fa15-4ee2-89a2-cbab79dd66ca",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "d1879bda-01dd-43dd-afdd-3e01578e7864",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(397));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "f2919aa8-c48b-4311-870f-2ae3c80ac7fe",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 14, 59, 53, 803, DateTimeKind.Utc).AddTicks(411));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "2bacd63b-a302-42e9-acf8-8eb165a5e135");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "3a6e1576-43af-4dde-b894-27f28d460084");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "3cc9c957-c7a1-455e-ad88-43e8f6157695");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "4311838a-c6b2-467c-836d-0237bb196cbe");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "45959950-fcab-4793-b1ce-422d102aa50b");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "46a4af13-d57a-4dab-9cfa-2247be54be4a");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "5bf3cd2b-40f2-41f0-804f-1febe6d25863");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "86f6bf50-a466-4ae8-a1f4-7bfbaf8b0e96");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "ec00060f-ef87-47d8-8ddc-873d2aa81add");

            migrationBuilder.DeleteData(
                schema: "cat",
                table: "exams",
                keyColumn: "id",
                keyValue: "f46d018a-63c3-4e83-a7e9-b381dcae9cd1");

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "35531282-6772-413c-99a0-57c8a7059c49",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "687e87df-d57a-4578-86df-3dc1938bfabb",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "c765cb93-f518-45ca-8372-0aa288f9d5b3",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "answers",
                keyColumn: "id",
                keyValue: "d079864f-2995-4357-8d3f-2784a1bffd23",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "0293d928-8ec7-4bf7-82cf-894235220294",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(343));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "7b70ddba-b8b0-42f8-961e-20785f0f564b",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "999abd49-0b6d-4fd0-81f4-0a419b71bac8",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(349));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "abdbeff3-9840-4200-a8c6-e1f1e3d0c428",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(336));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "c363cdf9-cadb-4090-a03d-43c4f5303e9b",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "levels",
                keyColumn: "id",
                keyValue: "d3dd9e4d-0170-45ce-9ee2-78b9f8770e38",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "01fd1f9c-78c4-41b1-a379-1229eba16808",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "33ae4edc-9bc7-4201-afda-28d5cfa4e84e",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "42fe49d6-44f9-4006-af32-88f20c315023",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1046));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questionTypes",
                keyColumn: "id",
                keyValue: "6f01c413-497a-4745-93d4-4e41d254fdad",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1043));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "questions",
                keyColumn: "id",
                keyValue: "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(3260));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "056d3522-078a-4d46-9262-d56ea7e557ea",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "244b45f1-fca2-4c6b-9a1f-71d7e44919c5",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "64f5b16d-5656-4418-8b40-7cb4c972bdd4",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "77f517bd-1855-4e0a-ac49-6893a707520c",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "7c99c1ee-a1c8-4e1b-a9a4-a174760e6dc2",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "80f521b3-c1d8-42ad-8c04-8e3d93e56fbe",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5200));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "b523c423-79c9-4d29-82ee-aec0ee4db213",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "b97ae130-8c1c-42b6-a47c-4e5e1fc056b6",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "bedbcaa0-fa15-4ee2-89a2-cbab79dd66ca",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5209));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "d1879bda-01dd-43dd-afdd-3e01578e7864",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                schema: "cat",
                table: "tags",
                keyColumn: "id",
                keyValue: "f2919aa8-c48b-4311-870f-2ae3c80ac7fe",
                column: "created_date",
                value: new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5189));
        }
    }
}
